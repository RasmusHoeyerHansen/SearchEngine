import {cleanup, fireEvent, render, screen} from "@testing-library/react";
import React from "react";
import {FileInput} from "./UploadInput";

describe("FileInput", () => {
    beforeEach(() => {
        jest.clearAllMocks();
        cleanup();
    });
    it("renders correctly with default pdf as filetype and matches" +
        " snapshot", () => {
        let {container} = render(<FileInput onChange={() => {
            return;
        }}/>)
        expect(container).toMatchSnapshot();
    });


    it('should render an file input element', () => {
        render(<FileInput onChange={() => {
            return;
        }}/>);

        const inputElement = screen.getByRole("input") as HTMLInputElement;
        expect(inputElement).toBeTruthy();
        expect(inputElement.type).toBe('file');
        expect(inputElement.multiple).toBe(true);
    });

    it('should be able to render a pdf file', function () {
        render(<FileInput onChange={() => {
            return;
        }}/>);

        const file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        let fileInput =  screen.getByRole("input") as HTMLInputElement;

        fireEvent.change(fileInput, {
            target: {files: [file]}
        });
        expect(fileInput.files).toBeTruthy();
        expect(fileInput.files?.length).toBeTruthy();
        expect(fileInput.files?.length).toBe(1);
    });
    it('should be able to render multiple pdf files', function () {
        render(<FileInput onChange={() => {
            return;
        }}/>);
        const file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        const file2 = new File([new ArrayBuffer(1)], 'testfile2.pdf');
        const file3 = new File([new ArrayBuffer(1)], 'testfile3.pdf');

        let fileInput = screen.getByRole("input") as HTMLInputElement;
        fireEvent.change(fileInput, {
            target: {files: [file, file2, file3]}
        });

        expect(fileInput.files).toBeTruthy();
        expect(fileInput.files?.length).toBeTruthy();
        expect(fileInput.files?.length).toBe(3);
    });
})