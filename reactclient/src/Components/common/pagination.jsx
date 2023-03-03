import React from "react";
import _ from "lodash";
import propTypes from "prop-types";
const Pagination = ({ pageSize, itemsCount, onPageChange, currentPage }) => {
  const pagesCount = Math.ceil(itemsCount / pageSize);
  const pages = _.range(1, pagesCount + 1);
  if (pages.length === 1) return null;
  return (
    <nav aria-label="...">
      <ul className="pagination">
        {pages.map((page) => (
          <li
            key={page}
            className={currentPage === page ? "page-item active" : "page-item"}
          >
            <a
              style={{ cursor: "pointer" }}
              onClick={() => onPageChange(page)}
              className="page-link"
              href="#a"
            >
              {page}
            </a>
          </li>
        ))}
      </ul>
    </nav>
  );
};
Pagination.propTypes = {
  pageSize: propTypes.number.isRequired,
  itemsCount: propTypes.number.isRequired,
  onPageChange: propTypes.func.isRequired,
  currentPage: propTypes.number.isRequired,
};
export default Pagination;
