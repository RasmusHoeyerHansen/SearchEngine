import { jsx as _jsx } from "react/jsx-runtime";
import { cleanup, fireEvent, render, screen } from "@testing-library/react";
import FileUploadContainer from "./FileUploadContainer";
describe("FileUploadContainer", function () {
    beforeEach(function () {
        jest.clearAllMocks();
        cleanup();
    });
    it('Matches snapshot', function () {
        var component = CreateComponent();
        expect(component).toMatchSnapshot();
    });
    it('should call submit on submit click', function () {
        var file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        var mockFunction = jest.fn();
        var content = CreateComponent();
        fireEvent.change(content, {
            target: { files: [file] }
        });
    });
    var CreateComponent = function () {
        render(_jsx(FileUploadContainer, {}, void 0));
        return screen.getByTestId('FileUploadContainer');
    };
});
