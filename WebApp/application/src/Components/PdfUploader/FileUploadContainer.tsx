import {ChangeEvent, FC, FormEvent, PropsWithChildren, useState} from "react";
import {FileUploadForm} from "./FileUploadForm";


export interface IPdfUploadContainerProps {
    onSubmit: (event:SubmitEvent) => void;
    onFileUpload:(event:FormEvent<HTMLInputElement> ) => void;
}

export const FileUploadContainer = (props : IPdfUploadContainerProps) => {
    const [pdfFiles, setState] = useState<File[]>()

    let displayText = "Upload a PDF file to contribute to the search engine."
    const onFileSelectionChanged = (event: ChangeEvent<HTMLInputElement>) => {
        let selectedFiles: File[] = [];

        const element = event.currentTarget as HTMLInputElement;

        let fileList: FileList | null = element.files;
        if (fileList) {
            for (let itm in fileList) {
                let item: File = fileList[itm];
                if (!selectedFiles.includes(item))
                    selectedFiles.push(item);
            }
        }
        setState(selectedFiles);
    }

    return (<div className={"PdfUploadContainer"}>
        <FileUploadForm onSubmit={props.onSubmit} onChange={onFileSelectionChanged}/>
    </div>)
}

const z : FC<HTMLInputElement> = (props : PropsWithChildren<HTMLInputElement>) : JSX.Element => {
    return <div>dsa</div>
}

export default FileUploadContainer;