import React, {FormEvent} from "react";
import {
    cleanup,
    fireEvent,
    render,
    screen
} from "@testing-library/react";
import FileUploadContainer from "./FileUploadContainer";


describe("FileUploadContainer", () => {


    beforeEach(() => {
        jest.clearAllMocks();
        cleanup();
    });
    it('Matches snapshot', function () {
        let component = CreateComponent();
        expect(component).toMatchSnapshot();
    });

    it('should call submit on submit click', function () {
        const file = new File([new ArrayBuffer(1)], 'testfile.pdf');
        let mockFunction = jest.fn()
        let content = CreateComponent();
        fireEvent.change(content, {
            target: {files: [file]}
        });
    });

    interface testProps {
        onSubmit?: (event:SubmitEvent) => void;
        onChange?:(event:FormEvent<HTMLInputElement> ) => void
    }

    const CreateComponent = () => {
        render(<FileUploadContainer />);
        return screen.getByTestId('FileUploadContainer') as HTMLInputElement;
    };
})