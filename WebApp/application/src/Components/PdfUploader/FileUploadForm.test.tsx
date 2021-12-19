import {render, unmountComponentAtNode} from "react-dom";
import {act} from "react-dom/test-utils";
import {FileUploadForm} from "./FileUploadForm";
import renderer from "react-test-renderer";
import React from "react";

describe("FileUploadForm", () => {
    let container: HTMLDivElement;
    beforeEach(() => {
        // setup a DOM element as a render target
        container = document.createElement("div");
        document.body.appendChild(container);
    });

    afterEach(() => {
        // cleanup on exiting
        unmountComponentAtNode(container);
        container.remove();
    });

    it("renders correctly with default pdf as filetype and matches" +
        " snapshot", () => {
        const tree = renderer
            .create(<FileUploadForm onChange={() => {
                return;
            }}/>)
            .toJSON();
        expect(tree).toMatchSnapshot();
    });



})
