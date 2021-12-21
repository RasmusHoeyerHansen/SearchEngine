import React, {ChangeEvent} from 'react'
import {cleanup, render, screen} from '@testing-library/react'
import {FileUploadForm} from "./FileUploadForm";

describe("FileUploadForm", () => {
    beforeEach(() => {
        jest.clearAllMocks();
        cleanup();
    });

    it("renders correctly with default pdf as filetype and matches" +
        " snapshot", () => {
        expect(CreateComponent()).toMatchSnapshot();
    });


    it('should render a form element', () => {
        const element = CreateComponent();
        expect(element).toBeInstanceOf(HTMLFormElement)
    });

    interface testProps {
        onChange?: (event: ChangeEvent<HTMLInputElement>) => void;
        onSubmit?: (event:SubmitEvent) => void;
    }

    const CreateComponent = (props:testProps = {}) => {
        let change = (event: ChangeEvent<HTMLInputElement>) => {return};
        let submit = (event:SubmitEvent) => {return};

        if (props.onChange){
            change = props.onChange;
        }
        if (props.onSubmit){
            submit = props.onSubmit;
        }
        render(<FileUploadForm onSubmit={submit} onChange={change}/>)
        return screen.getByRole("form") as HTMLInputElement;
    };


})
