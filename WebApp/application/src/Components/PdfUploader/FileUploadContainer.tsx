import {ChangeEvent, useState} from "react";
import {FileUploadForm} from "./FileUploadForm";



const UploadedFile = () : JSX.Element => {
    return <div role = "uploaded files"/>;
}

export const FileUploadContainer = () => {
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

    const onFileSubmit  = (event : SubmitEvent) => {


    }

    return (<div className={"PdfUploadContainer"} data-testid='FileUploadContainer'>
        <FileUploadForm onSubmit={onFileSubmit} onChange={onFileSelectionChanged}/>
        <UploadedFile />
    </div>)
}

export default FileUploadContainer;