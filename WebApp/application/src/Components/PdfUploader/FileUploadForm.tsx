import {ChangeEvent} from "react";

export interface IFileUploadFormProps extends IFileUploadFormOptionalProps {
    onChange: (event: ChangeEvent<HTMLInputElement>) => void;
}

interface IFileUploadFormOptionalProps {
    fileTypes?: [ValidFileTypes]
}

type ValidFileTypes = 'application/pdf' | 'application/vnd.ms-excel';

export const FileUploadForm = ({
                                   onChange, fileTypes = ['application/pdf']
                               }: IFileUploadFormProps) => {
    let acceptFileTypes: string = fileTypes.join(',');
    return (<form id="FileUploadForm">
        <input id={'FileUploadForm-input'}
               type="file"
               name="formFile" multiple
               accept={acceptFileTypes}
               onChange={onChange}
        />
        <input id={"FileUploadForm-submit"} type={"submit"}/>
        <label htmlFor="pdfInputForm"/>
    </form>);
}
