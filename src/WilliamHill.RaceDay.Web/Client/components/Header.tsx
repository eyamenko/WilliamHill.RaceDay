import * as React from "react";
import Navbar from "./Navbar";

class Header extends React.Component {
    render() {
        return (
            <header>
                <div className="container">
                    <Navbar/>
                </div>
            </header>
        );
    }
}

export default Header;