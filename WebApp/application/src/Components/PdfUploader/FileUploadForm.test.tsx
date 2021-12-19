import React from 'react'
import {fireEvent, getByRole, render} from '@testing-library/react'
import {FileUploadForm} from "./FileUploadForm";


describe("FileUploadForm", () => {


    beforeEach(() => {
        jest.clearAllMocks();
    });
    it("renders correctly with default pdf as filetype and matches" +
        " snapshot", () => {
        let {container} = render(<FileUploadForm onChange={() => {
            return;
        }}/>)
        expect(container).toMatchSnapshot();
    });


    it('should render a form element', () => {
        let {container} = render(<FileUploadForm onChange={() => {
            return;
        }}/>);

        // eslint-disable-next-line testing-library/no-node-access,testing-library/no-container
        const element = container.querySelector('#FileUploadForm');
        expect(element).toBeInstanceOf(HTMLFormElement)
    });
    it('should render an file input element', () => {
        let {container} = render(<FileUploadForm onChange={() => {
            return;
        }}/>);

        // eslint-disable-next-line testing-library/no-node-access,testing-library/no-container
        const inputElement = container.querySelector('#FileUploadForm-input') as HTMLInputElement;
        expect(inputElement).toBeInstanceOf(HTMLInputElement)
        expect(inputElement.type).toBe('file');
        expect(inputElement.multiple).toBe(true);
    });

    it('should be able to render a pdf file', function () {
        let {container} = render(<FileUploadForm onChange={() => {
            return;
        }}/>);

        const file = new File([new ArrayBuffer(1)], 'testfile.pdf');

        // eslint-disable-next-line testing-library/prefer-screen-queries,testing-library/no-node-access,testing-library/no-container
        let fileInput =  container.querySelector("#FileUploadForm-input") as HTMLInputElement;
        fireEvent.change(fileInput, {
            target: {files: [file]}
        });
        expect(fileInput.files).toBeTruthy();
        expect(fileInput.files?.length).toBeTruthy();
        expect(fileInput.files?.length).toBe(1);
    });
    it('should be able to render multiple pdf files', function () {
        let {container} = render(<FileUploadForm onChange={() => {
            return;
        }}/>);
        const file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        const file2 = new File([new ArrayBuffer(1)], 'testfile2.pdf');
        const file3 = new File([new ArrayBuffer(1)], 'testfile3.pdf');

        // get the upload button
        // eslint-disable-next-line testing-library/prefer-screen-queries,testing-library/no-node-access,testing-library/no-container
        let fileInput =  container.querySelector("#FileUploadForm-input") as HTMLInputElement;
        fireEvent.change(fileInput, {
            target: {files: [file, file2, file3]}
        });

        expect(fileInput.files).toBeTruthy();
        expect(fileInput.files?.length).toBeTruthy();
        expect(fileInput.files?.length).toBe(3);
    });

})
