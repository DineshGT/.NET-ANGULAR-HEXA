"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.course = exports.category = exports.status = void 0;
var status;
(function (status) {
    status["eligible"] = "Eligible";
    status["noteligible"] = "Not Eligible";
})(status || (exports.status = status = {}));
var category;
(function (category) {
    category["Frontend"] = "Front-end";
    category["Backend"] = "Back-end";
    category["Both"] = "Full-Stack";
})(category || (exports.category = category = {}));
var course;
(function (course) {
    course["Angular"] = "Angular";
    course["Nodejs"] = "NodeJs";
    course["Fullstack"] = "Full-Stack";
})(course || (exports.course = course = {}));
