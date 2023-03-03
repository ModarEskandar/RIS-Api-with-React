import _ from "lodash";
export function paginate(items, pageNumber, pageSize) {
  const firstItemIndex = (pageNumber - 1) * pageSize;
  return _(items).slice(firstItemIndex).take(pageSize).value();
}
