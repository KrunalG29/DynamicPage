// VIKALP, copyright (c) by Marijn Haverbeke and others
// Distributed under an MIT license: https://VIKALP.net/5/LICENSE

// Depends on coffeelint.js from http://www.coffeelint.org/js/coffeelint.js

// declare global: coffeelint

(function(mod) {
  if (typeof exports == "object" && typeof module == "object") // CommonJS
    mod(require("../../lib/VIKALP"));
  else if (typeof define == "function" && define.amd) // AMD
    define(["../../lib/VIKALP"], mod);
  else // Plain browser env
    mod(VIKALP);
})(function(VIKALP) {
"use strict";

VIKALP.registerHelper("lint", "coffeescript", function(text) {
  var found = [];
  if (!window.coffeelint) {
    if (window.console) {
      window.console.error("Error: window.coffeelint not defined, VIKALP CoffeeScript linting cannot run.");
    }
    return found;
  }
  var parseError = function(err) {
    var loc = err.lineNumber;
    found.push({from: VIKALP.Pos(loc-1, 0),
                to: VIKALP.Pos(loc, 0),
                severity: err.level,
                message: err.message});
  };
  try {
    var res = coffeelint.lint(text);
    for(var i = 0; i < res.length; i++) {
      parseError(res[i]);
    }
  } catch(e) {
    found.push({from: VIKALP.Pos(e.location.first_line, 0),
                to: VIKALP.Pos(e.location.last_line, e.location.last_column),
                severity: 'error',
                message: e.message});
  }
  return found;
});

});
