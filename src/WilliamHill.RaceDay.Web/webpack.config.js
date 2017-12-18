const path = require("path");
const webpack = require("webpack");
const {CheckerPlugin} = require("awesome-typescript-loader");

module.exports = {
    entry: {
        common: [
            "promise-polyfill",
            "whatwg-fetch",
            "./Client/styles/bootstrap.scss"
        ],
        main: "./Client/index.tsx"
    },
    output: {
        filename: "[name].js",
        path: path.resolve(__dirname, "./wwwroot/dist"),
        publicPath: "dist/"
    },
    resolve: {
        extensions: [".ts", ".tsx", ".js", ".jsx"]
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: "awesome-typescript-loader?silent=true"
            },
            {
                test: /\.scss$/,
                use: [
                    "style-loader",
                    "css-loader",
                    {
                        loader: "postcss-loader",
                        options: {
                            plugins: () => [
                                require("precss"),
                                require("autoprefixer")
                            ]
                        }
                    },
                    "sass-loader"
                ]
            }
        ]
    },
    plugins: [
        new CheckerPlugin(),
        new webpack.optimize.CommonsChunkPlugin({
            name: "common",
            minChunks: (module, count) => module.context && module.context.indexOf("node_modules") !== -1 || count >= 2
        })
    ]
};