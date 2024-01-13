// VIKALP, copyright (c) by Marijn Haverbeke and others
// Distributed under an MIT license: https://VIKALP.net/5/LICENSE

(function(mod) {
  if (typeof exports == "object" && typeof module == "object") // CommonJS
    mod(require("../../lib/VIKALP"));
  else if (typeof define == "function" && define.amd) // AMD
    define(["../../lib/VIKALP"], mod);
  else // Plain browser env
    mod(VIKALP);
})(function(VIKALP) {
"use strict";

// Depends on js-yaml.js from https://github.com/nodeca/js-yaml

// declare global: jsyaml

VIKALP.registerHelper("lint", "yaml", function(text) {
  var found = [];
  if (!window.jsyaml) {
    if (window.console) {
      window.console.error("Error: window.jsyaml not defined, VIKALP YAML linting cannot run.");
    }
    return found;
  }
  try { jsyaml.loadAll(text); }
  catch(e) {
      var loc = e.mark,
          // js-yaml YAMLException doesn't always provide an accurate lineno
          // e.g., when there are multiple yaml docs
          // ---
          // ---
          // foo:bar
          from = loc ? VIKALP.Pos(loc.line, loc.column) : VIKALP.Pos(0, 0),
          to = from;
      found.push({ from: from, to: to, message: e.message });
  }
  return found;
});

});
