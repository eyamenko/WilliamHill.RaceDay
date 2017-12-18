import * as React from "react";
import {LoadingComponentProps} from "react-loadable";
import Loader from "./Loader";

class Loading extends React.Component<LoadingComponentProps> {
    render() {
        return <Loader/>;
    }
}

export default Loading;