import {ChangeEvent, useState} from "react";
import {FileUploadForm, IFileUploadFormProps} from "./FileUploadForm";


export interface IPdfUploadContainerProps extends IFileUploadFormProps {

}

export const PdfUploadContainer = () => {

    const [pdfFiles, setState] = useState<File[]>()
    const [count, setCountState] = useState(0);

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
        setCountState(selectedFiles.length)
    }


    return (<div className={"PdfUploadContainer"}>
        <FileUploadForm onChange={onFileSelectionChanged}/>
        <div>
            {pdfFiles?.length}
        </div>
    </div>)
}

export default PdfUploadContainer;