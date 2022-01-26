import { jsx as _jsx } from "react/jsx-runtime";
import { render, unmountComponentAtNode } from "react-dom";
import App from "./App";
var container;
beforeEach(function () {
    // setup a DOM element as a render target
    container = document.createElement("div");
    document.body.appendChild(container);
});
afterEach(function () {
    // cleanup on exiting
    unmountComponentAtNode(container);
    container.remove();
});
it('should render', function () {
    render(_jsx(App, {}, void 0), container);
});
