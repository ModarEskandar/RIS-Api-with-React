import _ from "lodash";

export function group(groupList, selectedItem) {
  // get differences between the tow arrays

  return _.xor(groupList, selectedItem);
}
