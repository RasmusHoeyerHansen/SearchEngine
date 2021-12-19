import {FileInput, IFileInputProps, ValidFileTypes} from "./UploadInput";

export interface IFileUploadFormProps extends IFileUploadFormOptionalProps,IFileInputProps{
    onSubmit: (event:SubmitEvent) => void;
}

interface IFileUploadFormOptionalProps {
    fileTypes?: [ValidFileTypes]
}


export const FileUploadForm = ({
                                   onChange, fileTypes = ['application/pdf']
                               }: IFileUploadFormProps) =>
{
    let acceptFileTypes: string = fileTypes.join(',');
    return <form id="FileUploadForm" role='form'>
            <FileInput acceptedFileString={acceptFileTypes} onChange={onChange}/>
            </form>
}



