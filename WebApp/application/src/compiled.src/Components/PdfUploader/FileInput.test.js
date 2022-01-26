import { jsx as _jsx } from "react/jsx-runtime";
import { cleanup, fireEvent, render, screen } from "@testing-library/react";
import { FileInput } from "./FileInput";
describe("FileInput", function () {
    beforeEach(function () {
        jest.clearAllMocks();
        cleanup();
    });
    it("renders correctly with default pdf as filetype and matches" +
        " snapshot", function () {
        expect(CreateComponent()).toMatchSnapshot();
    });
    it('should render an file input element', function () {
        var inputElement = CreateComponent();
        expect(inputElement).toBeTruthy();
        expect(inputElement.type).toBe('file');
        expect(inputElement.multiple).toBe(true);
    });
    it('should be able to render a pdf file', function () {
        var _a, _b;
        var fileInput = CreateComponent();
        var file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        fireEvent.change(fileInput, {
            target: { files: [file] }
        });
        expect(fileInput.files).toBeTruthy();
        expect((_a = fileInput.files) === null || _a === void 0 ? void 0 : _a.length).toBeTruthy();
        expect((_b = fileInput.files) === null || _b === void 0 ? void 0 : _b.length).toBe(1);
    });
    it('should be able to render multiple pdf files', function () {
        var _a, _b;
        var file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        var file2 = new File([new ArrayBuffer(1)], 'testfile2.pdf');
        var file3 = new File([new ArrayBuffer(1)], 'testfile3.pdf');
        var fileInput = CreateComponent();
        fireEvent.change(fileInput, {
            target: { files: [file, file2, file3] }
        });
        expect(fileInput.files).toBeTruthy();
        expect((_a = fileInput.files) === null || _a === void 0 ? void 0 : _a.length).toBeTruthy();
        expect((_b = fileInput.files) === null || _b === void 0 ? void 0 : _b.length).toBe(3);
    });
    it('should call onChange once on change', function () {
        var mockFunction = jest.fn();
        var file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        var file2 = new File([new ArrayBuffer(1)], 'testfile2.pdf');
        var file3 = new File([new ArrayBuffer(1)], 'testfile3.pdf');
        var fileInput = CreateComponent(mockFunction);
        fireEvent.change(fileInput, {
            target: { files: [file] }
        });
        fireEvent.change(fileInput, {
            target: { files: [file2] }
        });
        fireEvent.change(fileInput, {
            target: { files: [file3] }
        });
        expect(mockFunction).toBeCalledTimes(3);
    });
    it('should call onChange once per change', function () {
        var mockFunction = jest.fn();
        var file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        var fileInput = CreateComponent(mockFunction);
        fireEvent.change(fileInput, {
            target: { files: [file] }
        });
        expect(mockFunction).toBeCalledTimes(1);
    });
    var CreateComponent = function (onChange) {
        if (!onChange) {
            render(_jsx(FileInput, { onChange: function () { return; } }, void 0));
        }
        else {
            render(_jsx(FileInput, { onChange: onChange }, void 0));
        }
        return screen.getByTestId("FileInput");
    };
});
