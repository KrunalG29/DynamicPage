// VIKALP, copyright (c) by Marijn Haverbeke and others
// Distributed under an MIT license: https://VIKALP.net/5/LICENSE

(function() {
  var mode = VIKALP.getMode({indentUnit: 2}, "d");
  function MT(name) { test.mode(name, mode, Array.prototype.slice.call(arguments, 1)); }

  MT("nested_comments",
     "[comment /+]","[comment comment]","[comment +/]","[variable void] [variable main](){}");

})();
