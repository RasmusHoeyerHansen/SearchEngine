import {ChangeEvent} from "react";

export interface IUploadFormProps {
    onChange: (event:ChangeEvent<HTMLInputElement>)  => void;
}


export const PdfUploadForm = (props : IUploadFormProps) =>
{
    return (
        <form id="pdfInputForm">
        <input type="file"
               name="formFile" multiple
               accept="application/pdf,application/vnd.ms-excel"
               onChange={props.onChange}
        />
            <input type={"submit"}/>
        </form>
    );
}

