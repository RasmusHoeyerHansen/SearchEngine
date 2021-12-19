import React, {ChangeEvent, FormEvent} from "react";
import {cleanup, render, screen} from "@testing-library/react";
import {FileUploadForm} from "./FileUploadForm";
import FileUploadContainer from "./FileUploadContainer";

describe("FileUploadContainer", () => {
    beforeEach(() => {
        jest.clearAllMocks();
        cleanup();
    });
    it('Matches snapshot', function () {
        let component = CreateComponent({});
        expect(component).toMatchSnapshot();
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