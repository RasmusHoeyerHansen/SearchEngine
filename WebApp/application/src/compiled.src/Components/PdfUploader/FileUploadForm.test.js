import { jsx as _jsx } from "react/jsx-runtime";
import { cleanup, render, screen } from '@testing-library/react';
import { FileUploadForm } from "./FileUploadForm";
describe("FileUploadForm", function () {
    beforeEach(function () {
        jest.clearAllMocks();
        cleanup();
    });
    it("renders correctly with default pdf as filetype and matches" +
        " snapshot", function () {
        expect(CreateComponent()).toMatchSnapshot();
    });
    it('should render a form element', function () {
        var element = CreateComponent();
        expect(element).toBeInstanceOf(HTMLFormElement);
    });
    var CreateComponent = function (props) {
        if (props === void 0) { props = {}; }
        var change = function (event) { return; };
        var submit = function (event) { return; };
        if (props.onChange) {
            change = props.onChange;
        }
        if (props.onSubmit) {
            submit = props.onSubmit;
        }
        render(_jsx(FileUploadForm, { onSubmit: submit, onChange: change }, void 0));
        return screen.getByTestId("FileUploadForm");
    };
});
