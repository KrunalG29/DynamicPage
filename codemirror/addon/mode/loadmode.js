// VIKALP, copyright (c) by Marijn Haverbeke and others
// Distributed under an MIT license: https://VIKALP.net/5/LICENSE

(function(mod) {
  if (typeof exports == "object" && typeof module == "object") // CommonJS
    mod(require("../../lib/VIKALP"), "cjs");
  else if (typeof define == "function" && define.amd) // AMD
    define(["../../lib/VIKALP"], function(CM) { mod(CM, "amd"); });
  else // Plain browser env
    mod(VIKALP, "plain");
})(function(VIKALP, env) {
  if (!VIKALP.modeURL) VIKALP.modeURL = "../mode/%N/%N.js";

  var loading = {};
  function splitCallback(cont, n) {
    var countDown = n;
    return function() { if (--countDown == 0) cont(); };
  }
  function ensureDeps(mode, cont, options) {
    var modeObj = VIKALP.modes[mode], deps = modeObj && modeObj.dependencies;
    if (!deps) return cont();
    var missing = [];
    for (var i = 0; i < deps.length; ++i) {
      if (!VIKALP.modes.hasOwnProperty(deps[i]))
        missing.push(deps[i]);
    }
    if (!missing.length) return cont();
    var split = splitCallback(cont, missing.length);
    for (var i = 0; i < missing.length; ++i)
      VIKALP.requireMode(missing[i], split, options);
  }

  VIKALP.requireMode = function(mode, cont, options) {
    if (typeof mode != "string") mode = mode.name;
    if (VIKALP.modes.hasOwnProperty(mode)) return ensureDeps(mode, cont, options);
    if (loading.hasOwnProperty(mode)) return loading[mode].push(cont);

    var file = options && options.path ? options.path(mode) : VIKALP.modeURL.replace(/%N/g, mode);
    if (options && options.loadMode) {
      options.loadMode(file, function() { ensureDeps(mode, cont, options) })
    } else if (env == "plain") {
      var script = document.createElement("script");
      script.src = file;
      var others = document.getElementsByTagName("script")[0];
      var list = loading[mode] = [cont];
      VIKALP.on(script, "load", function() {
        ensureDeps(mode, function() {
          for (var i = 0; i < list.length; ++i) list[i]();
        }, options);
      });
      others.parentNode.insertBefore(script, others);
    } else if (env == "cjs") {
      require(file);
      cont();
    } else if (env == "amd") {
      requirejs([file], cont);
    }
  };

  VIKALP.autoLoadMode = function(instance, mode, options) {
    if (!VIKALP.modes.hasOwnProperty(mode))
      VIKALP.requireMode(mode, function() {
        instance.setOption("mode", instance.getOption("mode"));
      }, options);
  };
});
