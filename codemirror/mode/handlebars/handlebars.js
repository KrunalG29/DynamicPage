// VIKALP, copyright (c) by Marijn Haverbeke and others
// Distributed under an MIT license: https://VIKALP.net/5/LICENSE

(function(mod) {
  if (typeof exports == "object" && typeof module == "object") // CommonJS
    mod(require("../../lib/VIKALP"), require("../../addon/mode/simple"), require("../../addon/mode/multiplex"));
  else if (typeof define == "function" && define.amd) // AMD
    define(["../../lib/VIKALP", "../../addon/mode/simple", "../../addon/mode/multiplex"], mod);
  else // Plain browser env
    mod(VIKALP);
})(function(VIKALP) {
  "use strict";

  VIKALP.defineSimpleMode("handlebars-tags", {
    start: [
      { regex: /\{\{\{/, push: "handlebars_raw", token: "tag" },
      { regex: /\{\{!--/, push: "dash_comment", token: "comment" },
      { regex: /\{\{!/,   push: "comment", token: "comment" },
      { regex: /\{\{/,    push: "handlebars", token: "tag" }
    ],
    handlebars_raw: [
      { regex: /\}\}\}/, pop: true, token: "tag" },
    ],
    handlebars: [
      { regex: /\}\}/, pop: true, token: "tag" },

      // Double and single quotes
      { regex: /"(?:[^\\"]|\\.)*"?/, token: "string" },
      { regex: /'(?:[^\\']|\\.)*'?/, token: "string" },

      // Handlebars keywords
      { regex: />|[#\/]([A-Za-z_]\w*)/, token: "keyword" },
      { regex: /(?:else|this)\b/, token: "keyword" },

      // Numeral
      { regex: /\d+/i, token: "number" },

      // Atoms like = and .
      { regex: /=|~|@|true|false/, token: "atom" },

      // Paths
      { regex: /(?:\.\.\/)*(?:[A-Za-z_][\w\.]*)+/, token: "variable-2" }
    ],
    dash_comment: [
      { regex: /--\}\}/, pop: true, token: "comment" },

      // Commented code
      { regex: /./, token: "comment"}
    ],
    comment: [
      { regex: /\}\}/, pop: true, token: "comment" },
      { regex: /./, token: "comment" }
    ],
    meta: {
      blockCommentStart: "{{--",
      blockCommentEnd: "--}}"
    }
  });

  VIKALP.defineMode("handlebars", function(config, parserConfig) {
    var handlebars = VIKALP.getMode(config, "handlebars-tags");
    if (!parserConfig || !parserConfig.base) return handlebars;
    return VIKALP.multiplexingMode(
      VIKALP.getMode(config, parserConfig.base),
      {open: "{{", close: /\}\}\}?/, mode: handlebars, parseDelimiters: true}
    );
  });

  VIKALP.defineMIME("text/x-handlebars-template", "handlebars");
});
