import React from 'react'
import {cleanup, render, screen} from '@testing-library/react'
import {FileUploadForm} from "./FileUploadForm";


describe("FileUploadForm", () => {
    beforeEach(() => {
        jest.clearAllMocks();
        cleanup();
    });
    it("renders correctly with default pdf as filetype and matches" +
        " snapshot", () => {
        let {container} = render(<FileUploadForm onChange={() => {
            return;
        }}/>)
        expect(container).toMatchSnapshot();
    });


    it('should render a form element', () => {
        render(<FileUploadForm onChange={() => {
            return;
        }}/>);

        const element = screen.getByRole('form')
        expect(element).toBeInstanceOf(HTMLFormElement)
    });

})
