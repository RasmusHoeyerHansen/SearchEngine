import {cleanup, fireEvent, render, screen} from "@testing-library/react";
import React, {ChangeEvent} from "react";
import {FileInput} from "./UploadInput";
import mock = jest.mock;

describe("FileInput", () => {
    beforeEach(() => {
        jest.clearAllMocks();
        cleanup();
    });

    it("renders correctly with default pdf as filetype and matches" +
        " snapshot", () => {
        expect(CreateComponent()).toMatchSnapshot();
    });


    it('should render an file input element', () => {
        const inputElement = CreateComponent()
        expect(inputElement).toBeTruthy();
        expect(inputElement.type).toBe('file');
        expect(inputElement.multiple).toBe(true);
    });

    it('should be able to render a pdf file', function () {
        CreateComponent();
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

        const file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        const file2 = new File([new ArrayBuffer(1)], 'testfile2.pdf');
        const file3 = new File([new ArrayBuffer(1)], 'testfile3.pdf');

        let fileInput = CreateComponent();
        fireEvent.change(fileInput, {
            target: {files: [file, file2, file3]}
        });

        expect(fileInput.files).toBeTruthy();
        expect(fileInput.files?.length).toBeTruthy();
        expect(fileInput.files?.length).toBe(3);
    });

    it('should call onChange once on change', () => {
        let mockFunction = jest.fn()
        const file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        const file2 = new File([new ArrayBuffer(1)], 'testfile2.pdf');
        const file3 = new File([new ArrayBuffer(1)], 'testfile3.pdf');
        let fileInput = CreateComponent(mockFunction);
        fireEvent.change(fileInput, {
            target: {files: [file]}
        });
        fireEvent.change(fileInput, {
            target: {files: [file2]}
        });
        fireEvent.change(fileInput, {
            target: {files: [file3]}
        });

        expect(mockFunction).toBeCalledTimes(3)
    });

    it('should call onChange once per change', () => {
        let mockFunction = jest.fn()
        const file = new File([new ArrayBuffer(1)], 'testfile.pdf');

        let fileInput = CreateComponent(mockFunction);
        fireEvent.change(fileInput, {
            target: {files: [file]}
        });

        expect(mockFunction).toBeCalledTimes(1)
    });

    const CreateComponent = (onChange?: (event: ChangeEvent<HTMLInputElement>) => void) : HTMLInputElement => {
        if (!onChange){
            render(<FileInput onChange={() => {return;}}/>);
        } else {
            render(<FileInput onChange={onChange}/>);
        }
        return screen.getByRole("input") as HTMLInputElement;
    };
})