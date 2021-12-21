import React, {FormEvent} from "react";
import {
    cleanup,
    createEvent, fireEvent,
    render,
    screen
} from "@testing-library/react";
import FileUploadContainer from "./FileUploadContainer";
import {IFileInputProps} from "./FileInput";


describe("FileUploadContainer", () => {
    let moqFileUploadForm = jest.mock("./FileInput");


    let moqFileInput = jest.mock("./FileInput");


    beforeEach(() => {
        jest.clearAllMocks();
        cleanup();
    });
    it('Matches snapshot', function () {
        let component = CreateComponent({});
        expect(component).toMatchSnapshot();
    });

    it('should call submit on submit click', function () {
        let mockFunction = jest.fn()
        let content = CreateComponent({onSubmit: mockFunction});
        const myEvent = createEvent.submit(content)
        fireEvent(content, myEvent)

        expect(mockFunction).toBeCalledTimes(1);

    });

    interface testProps {
        onSubmit?: (event:SubmitEvent) => void;
        onFileUpload?:(event:FormEvent<HTMLInputElement> ) => void
    }

    const CreateComponent = (props : testProps) => {
        let submit = (event : SubmitEvent) => {return;}
        let upload = (event:FormEvent<HTMLInputElement> ) => {return;}
        if (props.onSubmit){
            submit = props.onSubmit;
        }
        if (props.onFileUpload){
            upload = props.onFileUpload;
        }

        render(<FileUploadContainer onFileUpload={upload} onSubmit={submit}/>);
        return screen.getByRole("form") as HTMLInputElement;
    };
})