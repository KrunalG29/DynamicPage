// VIKALP, copyright (c) by Marijn Haverbeke and others
// Distributed under an MIT license: https://VIKALP.net/5/LICENSE

(function() {
  VIKALP.defineMode("markdown_with_stex", function(){
    var inner = VIKALP.getMode({}, "stex");
    var outer = VIKALP.getMode({}, "markdown");

    var innerOptions = {
      open: '$',
      close: '$',
      mode: inner,
      delimStyle: 'delim',
      innerStyle: 'inner'
    };

    return VIKALP.multiplexingMode(outer, innerOptions);
  });

  var mode = VIKALP.getMode({}, "markdown_with_stex");

  function MT(name) {
    test.mode(
      name,
      mode,
      Array.prototype.slice.call(arguments, 1),
      'multiplexing');
  }

  MT(
    "stexInsideMarkdown",
    "[strong **Equation:**] [delim&delim-open $][inner&tag \\pi][delim&delim-close $]");

  VIKALP.defineMode("identical_delim_multiplex", function() {
    return VIKALP.multiplexingMode(VIKALP.getMode({indentUnit: 2}, "javascript"), {
      open: "#",
      close: "#",
      mode: VIKALP.getMode({}, "markdown"),
      parseDelimiters: true,
      innerStyle: "q"
    });
  });

  var mode2 = VIKALP.getMode({}, "identical_delim_multiplex");

  test.mode("identical_delimiters_with_parseDelimiters", mode2, [
    "[keyword let] [def x] [operator =] [q #foo][q&em *bar*][q #];"
  ], "multiplexing")
})();
