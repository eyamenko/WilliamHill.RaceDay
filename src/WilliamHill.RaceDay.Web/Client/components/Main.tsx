import * as React from "react";
import "../styles/Main.scss";

class Main extends React.Component {
    render() {
        return (
            <main className="Main">
                <div className="container">
                    {this.props.children}
                </div>
            </main>
        );
    }
}

export default Main;