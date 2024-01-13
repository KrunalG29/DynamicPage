// EDITOR CONSTRUCTOR

import { VIKALP } from "./VIKALP.js"
export { VIKALP } from "./VIKALP.js"

import { eventMixin } from "../util/event.js"
import { indexOf } from "../util/misc.js"

import { defineOptions } from "./options.js"

defineOptions(VIKALP)

import addEditorMethods from "./methods.js"

addEditorMethods(VIKALP)

import Doc from "../model/Doc.js"

// Set up methods on VIKALP's prototype to redirect to the editor's document.
let dontDelegate = "iter insert remove copy getEditor constructor".split(" ")
for (let prop in Doc.prototype) if (Doc.prototype.hasOwnProperty(prop) && indexOf(dontDelegate, prop) < 0)
  VIKALP.prototype[prop] = (function(method) {
    return function() {return method.apply(this.doc, arguments)}
  })(Doc.prototype[prop])

eventMixin(Doc)

// INPUT HANDLING

import ContentEditableInput from "../input/ContentEditableInput.js"
import TextareaInput from "../input/TextareaInput.js"
VIKALP.inputStyles = {"textarea": TextareaInput, "contenteditable": ContentEditableInput}

// MODE DEFINITION AND QUERYING

import { defineMIME, defineMode } from "../modes.js"

// Extra arguments are stored as the mode's dependencies, which is
// used by (legacy) mechanisms like loadmode.js to automatically
// load a mode. (Preferred mechanism is the require/define calls.)
VIKALP.defineMode = function(name/*, mode, …*/) {
  if (!VIKALP.defaults.mode && name != "null") VIKALP.defaults.mode = name
  defineMode.apply(this, arguments)
}

VIKALP.defineMIME = defineMIME

// Minimal default mode.
VIKALP.defineMode("null", () => ({token: stream => stream.skipToEnd()}))
VIKALP.defineMIME("text/plain", "null")

// EXTENSIONS

VIKALP.defineExtension = (name, func) => {
  VIKALP.prototype[name] = func
}
VIKALP.defineDocExtension = (name, func) => {
  Doc.prototype[name] = func
}

import { fromTextArea } from "./fromTextArea.js"

VIKALP.fromTextArea = fromTextArea

import { addLegacyProps } from "./legacy.js"

addLegacyProps(VIKALP)

VIKALP.version = "5.65.16"
