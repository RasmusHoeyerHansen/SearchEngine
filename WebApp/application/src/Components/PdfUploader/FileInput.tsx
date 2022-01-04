import {ChangeEvent} from "react";

export interface IFileInputProps{
    acceptedFileString? : string;
    onChange: (event: ChangeEvent<HTMLInputElement>) => void;
}



export type ValidFileTypes = 'application/pdf' | 'application/vnd.ms-excel';

export function FileInput ({acceptedFileString = "application/pdf", onChange}: IFileInputProps) : JSX.Element {
    return <input id={'FileUploadForm-input'}
                  type="file"
                  name="formFile" multiple
                  accept={acceptedFileString}
                  onChange={onChange}
                  role="input"
                  data-testid = "FileInput"
    />
}