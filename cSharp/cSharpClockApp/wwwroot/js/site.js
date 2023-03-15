// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Programming Languages and Frameworks

// Clock

function getSecondsSinceStartOfDay() {
    // below returning new date / seconds + min + hours
    // return example 43590
    let hour = new Date().getHours()
    let min = new Date().getMinutes()
    let sec = new Date().getSeconds()
    // console.log('hour', hour, 'min', min, 'sec', sec)
    let time = {hour: hour, min: min, sec: sec}

    // return time;
    return new Date().getSeconds() + 
      new Date().getMinutes() * 60 + 
      new Date().getHours() * 3600;
}

setInterval( function() {
    // getting time
    var time = getSecondsSinceStartOfDay();

    let hours = parseInt(time/3600)  
    var h_angle = (180 + hours*30)%360
    document.getElementById('hour').style.transform = `rotate(${h_angle}deg)`

    // minutes
    let minutes = parseInt((time - hours*3600)/60)
    var m_angle = (180 + minutes*6)%360
    document.getElementById('minutes').style.transform = `rotate(${m_angle}deg)`

    // seconds
    let seconds = parseInt((time-minutes*60-hours*3600))
    var s_angle = (180 + seconds*6)%360
    document.getElementById('seconds').style.transform = `rotate(${s_angle}deg)`


}, 1000);

const URL = {
    "characters": "https://dojo.navyladyveteran.com/characters/",
    "squishies": "https://dojo.navyladyveteran.com/squishies/",
    "stickers": "https://dojo.navyladyveteran.com/stickers/",
    "octocats": "https://dojo.navyladyveteran.com/octocats/"
}
const StickerURL = "https://dojo.navyladyveteran.com/stickers/"

// API

async function getStickers() {
    var res = await fetch(`${StickerURL}`)
    var data = await res.json()
    console.log("Am I pulling the api:", data)
    for (var i = 0; i < data.length; i++) {
        var node = document.createElement('div')
        node.setAttribute("class", "apiBox")
        var h3 = document.createElement('h3')
        var name = document.createTextNode(data[i].name)
        h3.appendChild(name)
        var img = document.createElement('img')
        img.src = `${data[i].img}`
        img.alt = `${data[i].name}`
        node.appendChild(h3)
        node.appendChild(img)
        var form = document.createElement('form')
        form.setAttribute('method', 'post')
        form.setAttribute('action', '/Image/CreateImage')
        var nameInput = document.createElement('input')
        var imgInput = document.createElement('input')
        nameInput.setAttribute('type', 'hidden')
        imgInput.setAttribute('type', 'hidden')
        var namesrc = `${data[i].name}`
        var imgsrc = `${data[i].img}`
        nameInput.setAttribute('name', 'Title')
        imgInput.setAttribute('name', 'Url')
        nameInput.setAttribute('value', namesrc)
        imgInput.setAttribute('value', imgsrc)
        var button = document.createElement('button')
        var submit = document.createTextNode('Save Image to Database')
        button.appendChild(submit)
        form.appendChild(nameInput)
        form.appendChild(imgInput)
        form.appendChild(button)
        node.appendChild(form)
        document.getElementById('api').appendChild(node)
    }
}
getStickers()