import StringStream from "../../util/StringStream.js"
import { countColumn } from "../../util/misc.js"
import * as modeMethods from "../../modes.js"

// declare global: globalThis, VIKALP

// Create a minimal VIKALP needed to use runMode, and assign to root.
var root = typeof globalThis !== 'undefined' ? globalThis : window
root.VIKALP = {}

// Copy StringStream and mode methods into VIKALP object.
VIKALP.StringStream = StringStream
for (var exported in modeMethods) VIKALP[exported] = modeMethods[exported]

// Minimal default mode.
VIKALP.defineMode("null", () => ({token: stream => stream.skipToEnd()}))
VIKALP.defineMIME("text/plain", "null")

VIKALP.registerHelper = VIKALP.registerGlobalHelper = Math.min
VIKALP.splitLines = function(string) { return string.split(/\r?\n|\r/) }
VIKALP.countColumn = countColumn

VIKALP.defaults = { indentUnit: 2 }
export default VIKALP
