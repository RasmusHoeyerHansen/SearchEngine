import {IFileUploadFormProps} from "./FileUploadForm";

interface IFileInputProps extends IFileUploadFormProps{
    acceptedFileString? : string;
}



export type ValidFileTypes = 'application/pdf' | 'application/vnd.ms-excel';

export function FileInput ({acceptedFileString = "application/pdf", onChange}: IFileInputProps) : JSX.Element {
    return <input id={'FileUploadForm-input'}
                  type="file"
                  name="formFile" multiple
                  accept={acceptedFileString}
                  onChange={onChange}
                  role="input"
    />
}