import {FileUploadForm} from "./FileUploadForm";

describe("FileUploadForm", () => {

    it("renders correctly with default filetype", () => {
        const tree = renderer
            .create(<FileUploadForm onChange={() => {
                return
            }}/>)
            .toJSON();
        expect(tree).toMatchSnapshot();
    });

    const component = shallow(<FileUploadForm onChange={() => {
        return
    }}/>);

    it('should render a label and a file input field', () => {
        expect(component.find('input[type="file"]')).toBeTruthy();
    });
})
