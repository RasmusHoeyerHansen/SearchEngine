import React, {Fragment, ReactNode} from "react";

function UploadForm() {
    return <div>
    </div>
}

export default function PdfFileUploadForm() {
    return(
        <div>
            <input
                type="file"
                name="Upload PDF file"
                accept="application/pdf,application/vnd.ms-excel"/>
            <p>Upload a file to search its contents.</p>
        </div>
    )
}