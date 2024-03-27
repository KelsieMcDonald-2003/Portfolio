const webpack = require('webpack');
const path = require('path');
const htmlWebpackPlugin = require("html-webpack-plugin");
const copyPlugin = require("copy-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CssMinimizerPlugin = require('css-minimizer-webpack-plugin');

require('dotenv').config();

const isProduction = (process.env.NODE_ENV === 'production');

const fileNamePrefix = isProduction ? '[chunkhash].' : '';

module.exports = {
    mode: isProduction ? 'production' : 'development',
    entry: {
        main: './src/js/main.js',
        navbar: './src/js/navbar.js',
        lottery: './src/js/lottery.js',
    },
    output:{
        path: path.resolve(__dirname, "dist"),
        filename: fileNamePrefix + '[name].js',
        clean: true,
    },
    target: 'web',
    devServer: {
        static: {
            directory: path.resolve(__dirname, "dist"),
        },
        devMiddleware: {
            index: "Index.html",
            writeToDisk: true,
        },
    },    
    devtool: isProduction ? 'inline-source-map' : 'source-map',
    module: {
        rules: [
            {
                test: /\.js$/i,
                exclude: /(node_modules)/,
                use: {
                  loader: 'babel-loader',
                  options: {
                    presets: ['@babel/preset-env'],
                  },
                },
              },
              {
                test: /\.css$/,
                use: ['style-loader', 'css-loader'],
              },
              {
                test: /\.s[ac]ss$/i,
                use: [
                  isProduction ? MiniCssExtractPlugin.loader : 'style-loader',
                  'css-loader',
                  'sass-loader',
                ],
              },
              {
                test: /\.(svg|eot|ttf|woff|woff2)$/i,
                type: "asset/resource",
              },
              {
                test: /\.(png|jpg|gif)$/i,
                type: "asset/resource",
              },
        ],
    },
    plugins: [
        new htmlWebpackPlugin({
            template: path.resolve(__dirname, "./src/Index.html"),
            chunks: ["main"],
            inject: "body",
            filename: "Index.html",
        }),
        new htmlWebpackPlugin({
            template: path.resolve(__dirname, "./src/commoncode/Navbar.html"),
            chuncks: ["navbar"],
            inject: "body",
            filename: "Navbar.html"
          }),
        new htmlWebpackPlugin({
          template: path.resolve(__dirname, "./src/LotteryTicket.html"),
          chunks: ["main", "lottery"],
          inject: "body",
          filename: "LotteryTicket.html"
        })
    ],
    optimization: {
        minimizer: [
          new CssMinimizerPlugin(),
        ],
        splitChunks: {
          chunks: "all",
        },
    },
};