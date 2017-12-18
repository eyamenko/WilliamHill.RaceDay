import * as React from "react";

class Footer extends React.Component {
    render() {
        return (
            <footer>
                <div className="container">
                    <p className="text-center">
                        <strong>SPA Rocks!</strong> by <a href="https://github.com/eyamenko" target="_blank">
                        Eugene Yamenko</a>. The source code is licensed <a
                        href="http://opensource.org/licenses/mit-license.php" target="_blank">MIT</a>.
                    </p>
                </div>
            </footer>
        );
    }
}

export default Footer;