import { scrollbarModel } from "../display/scrollbars.js"
import { wheelEventPixels } from "../display/scroll_events.js"
import { keyMap, keyName, isModifierKey, lookupKey, normalizeKeyMap } from "../input/keymap.js"
import { keyNames } from "../input/keynames.js"
import { Line } from "../line/line_data.js"
import { cmp, Pos } from "../line/pos.js"
import { changeEnd } from "../model/change_measurement.js"
import Doc from "../model/Doc.js"
import { LineWidget } from "../model/line_widget.js"
import { SharedTextMarker, TextMarker } from "../model/mark_text.js"
import { copyState, extendMode, getMode, innerMode, mimeModes, modeExtensions, modes, resolveMode, startState } from "../modes.js"
import { addClass, contains, rmClass } from "../util/dom.js"
import { e_preventDefault, e_stop, e_stopPropagation, off, on, signal } from "../util/event.js"
import { splitLinesAuto } from "../util/feature_detection.js"
import { countColumn, findColumn, isWordCharBasic, Pass } from "../util/misc.js"
import StringStream from "../util/StringStream.js"

import { commands } from "./commands.js"

export function addLegacyProps(VIKALP) {
  VIKALP.off = off
  VIKALP.on = on
  VIKALP.wheelEventPixels = wheelEventPixels
  VIKALP.Doc = Doc
  VIKALP.splitLines = splitLinesAuto
  VIKALP.countColumn = countColumn
  VIKALP.findColumn = findColumn
  VIKALP.isWordChar = isWordCharBasic
  VIKALP.Pass = Pass
  VIKALP.signal = signal
  VIKALP.Line = Line
  VIKALP.changeEnd = changeEnd
  VIKALP.scrollbarModel = scrollbarModel
  VIKALP.Pos = Pos
  VIKALP.cmpPos = cmp
  VIKALP.modes = modes
  VIKALP.mimeModes = mimeModes
  VIKALP.resolveMode = resolveMode
  VIKALP.getMode = getMode
  VIKALP.modeExtensions = modeExtensions
  VIKALP.extendMode = extendMode
  VIKALP.copyState = copyState
  VIKALP.startState = startState
  VIKALP.innerMode = innerMode
  VIKALP.commands = commands
  VIKALP.keyMap = keyMap
  VIKALP.keyName = keyName
  VIKALP.isModifierKey = isModifierKey
  VIKALP.lookupKey = lookupKey
  VIKALP.normalizeKeyMap = normalizeKeyMap
  VIKALP.StringStream = StringStream
  VIKALP.SharedTextMarker = SharedTextMarker
  VIKALP.TextMarker = TextMarker
  VIKALP.LineWidget = LineWidget
  VIKALP.e_preventDefault = e_preventDefault
  VIKALP.e_stopPropagation = e_stopPropagation
  VIKALP.e_stop = e_stop
  VIKALP.addClass = addClass
  VIKALP.contains = contains
  VIKALP.rmClass = rmClass
  VIKALP.keyNames = keyNames
}
