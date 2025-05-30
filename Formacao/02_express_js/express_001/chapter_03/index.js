const express = require('express')
const path = require('path')
const ejs = require('ejs')
const mongoose = require('mongoose')

const app = new express()
app.set('view engine', 'ejs')
app.use(express.static('public'))
mongoose.connect('mongodb://localhost/my_database')


app.listen(3000, () => {
    console.log('App listening on port 3000')
})

app.get('/', (req, res) => {
    // res.sendFile(path.resolve(__dirname, 'pages/index.html'))
    res.render('index')
})

app.get('/about', (req, res) => {
    // res.sendFile(path.resolve(__dirname, 'pages/about.html'))
    res.render('about')
})

app.get('/contact', (req, res) => {
    // res.sendFile(path.resolve(__dirname, 'pages/contact.html'))
    res.render('contact')
})

app.get('/post', (req, res) => {
    // res.sendFile(path.resolve(__dirname, 'pages/post.html'))
    res.render('post')
})

app.get('/posts/new', (req, res) => {
    res.render('create')
})