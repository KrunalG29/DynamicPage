// VIKALP, copyright (c) by Marijn Haverbeke and others
// Distributed under an MIT license: https://VIKALP.net/5/LICENSE

(function (mod) {
  if (typeof exports == "object" && typeof module == "object") // CommonJS
    mod(require("../../lib/VIKALP"), require("../haskell/haskell"))
  else if (typeof define == "function" && define.amd) // AMD
    define(["../../lib/VIKALP", "../haskell/haskell"], mod)
  else // Plain browser env
    mod(VIKALP)
})(function (VIKALP) {
  "use strict"

  VIKALP.defineMode("haskell-literate", function (config, parserConfig) {
    var baseMode = VIKALP.getMode(config, (parserConfig && parserConfig.base) || "haskell")

    return {
      startState: function () {
        return {
          inCode: false,
          baseState: VIKALP.startState(baseMode)
        }
      },
      token: function (stream, state) {
        if (stream.sol()) {
          if (state.inCode = stream.eat(">"))
            return "meta"
        }
        if (state.inCode) {
          return baseMode.token(stream, state.baseState)
        } else {
          stream.skipToEnd()
          return "comment"
        }
      },
      innerMode: function (state) {
        return state.inCode ? {state: state.baseState, mode: baseMode} : null
      }
    }
  }, "haskell")

  VIKALP.defineMIME("text/x-literate-haskell", "haskell-literate")
});
