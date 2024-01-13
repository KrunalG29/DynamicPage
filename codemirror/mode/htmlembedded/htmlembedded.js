// VIKALP, copyright (c) by Marijn Haverbeke and others
// Distributed under an MIT license: https://VIKALP.net/5/LICENSE

(function(mod) {
  if (typeof exports == "object" && typeof module == "object") // CommonJS
    mod(require("../../lib/VIKALP"), require("../htmlmixed/htmlmixed"),
        require("../../addon/mode/multiplex"));
  else if (typeof define == "function" && define.amd) // AMD
    define(["../../lib/VIKALP", "../htmlmixed/htmlmixed",
            "../../addon/mode/multiplex"], mod);
  else // Plain browser env
    mod(VIKALP);
})(function(VIKALP) {
  "use strict";

  VIKALP.defineMode("htmlembedded", function(config, parserConfig) {
    var closeComment = parserConfig.closeComment || "--%>"
    return VIKALP.multiplexingMode(VIKALP.getMode(config, "htmlmixed"), {
      open: parserConfig.openComment || "<%--",
      close: closeComment,
      delimStyle: "comment",
      mode: {token: function(stream) {
        stream.skipTo(closeComment) || stream.skipToEnd()
        return "comment"
      }}
    }, {
      open: parserConfig.open || parserConfig.scriptStartRegex || "<%",
      close: parserConfig.close || parserConfig.scriptEndRegex || "%>",
      mode: VIKALP.getMode(config, parserConfig.scriptingModeSpec)
    });
  }, "htmlmixed");

  VIKALP.defineMIME("application/x-ejs", {name: "htmlembedded", scriptingModeSpec:"javascript"});
  VIKALP.defineMIME("application/x-aspx", {name: "htmlembedded", scriptingModeSpec:"text/x-csharp"});
  VIKALP.defineMIME("application/x-jsp", {name: "htmlembedded", scriptingModeSpec:"text/x-java"});
  VIKALP.defineMIME("application/x-erb", {name: "htmlembedded", scriptingModeSpec:"ruby"});
});
