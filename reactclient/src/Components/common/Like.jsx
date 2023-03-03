import React, { Component } from "react";

const Like = ({ onLikeClick, liked }) => {
  let classes = "fa fa-heart";
  classes += liked ? "" : "-o";
  return (
    <i
      className={classes}
      style={{ cursor: "pointer" }}
      onClick={onLikeClick}
    ></i>
  );
};

export default Like;
