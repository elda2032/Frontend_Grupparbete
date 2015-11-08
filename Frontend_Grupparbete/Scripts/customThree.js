// Variables
var container;
var controls, light;
container = document.getElementById("container");
var WIDTH = window.innerWidth;
var HEIGHT = window.innerHeight;
var angle = 45, aspect = WIDTH / HEIGHT, near = 0.1, far = 10000;

// World objects

var scene = new THREE.Scene();
var camera = new THREE.PerspectiveCamera(angle, aspect, near, far);
var renderer = new THREE.WebGLRenderer({ antialiasing: true });

// Renderer
renderer.setSize(WIDTH, HEIGHT);
//document.body.appendChild(renderer.domElement);
container.appendChild(renderer.domElement);

// Custom materials

var light = new THREE.SpotLight(0xFFFFFF, 1);
var material = new THREE.MeshLambertMaterial({ color: 0xFFFFFF });
var red = new THREE.MeshLambertMaterial({ color: 0xFF0000 });
var grey = new THREE.MeshLambertMaterial({ color: 0x222222 });

// Objects

var geometry = new THREE.CylinderGeometry(20, 21, 4, 48, 1, false);
var dial = new THREE.Mesh(geometry, material);

var geometry = new THREE.CubeGeometry(5, 2, 1);
geometry.applyMatrix(new THREE.Matrix4().makeTranslation(18, 0, 0));
var mark = new THREE.Mesh(geometry, grey);

var geometry = new THREE.CubeGeometry(15, 1, 2);
geometry.applyMatrix(new THREE.Matrix4().makeTranslation(15, 0, 0));
var second = new THREE.Mesh(geometry, red);

var geometry = new THREE.CubeGeometry(12, 1, 3);
geometry.applyMatrix(new THREE.Matrix4().makeTranslation(15, 0, 0));
var minute = new THREE.Mesh(geometry, material);

var geometry = new THREE.CubeGeometry(10, 1, 4);
geometry.applyMatrix(new THREE.Matrix4().makeTranslation(15, 0, 0));

var hour = new THREE.Mesh(geometry, material);

// Positioning

dial.position.x = 0;
dial.position.y = -3;
dial.position.z = 0;

mark.position.x = 0;
mark.position.y = -1.5;
mark.position.z = 0;

second.position.x = 0;
second.position.y = 0;
second.position.z = 0;

minute.position.x = 0;
minute.position.y = 1;
minute.position.z = 0;

hour.position.x = 0;
hour.position.y = 2;
hour.position.z = 0;

light.position.x = 0;
light.position.y = 100;
light.position.z = 0;
light.lookAt(dial.position);

camera.position.z = 40;
camera.position.y = 40;
camera.lookAt(dial.position);

// World building

scene.add(camera);
scene.add(light);
scene.add(dial);
scene.add(mark);
scene.add(second);
scene.add(minute);
scene.add(hour);

// Shadow

renderer.shadowMapEnabled = true;

light.castShadow = true;
light.shadowCameraNear = 1.0;
light.shadowDarkness = 0.5;

dial.castShadow = true;
dial.receiveShadow = true;

mark.castShadow = true;
mark.receiveShadow = true;

second.castShadow = true;
second.receiveShadow = true;

minute.castShadow = true;
minute.receiveShadow = true;

hour.castShadow = true;
hour.receiveShadow = true;

// Set initial time
var now = new Date();
hour.rotation.y = -((Math.PI * 2) * (now.getHours() / 12.0));
minute.rotation.y = -((Math.PI * 2) * (now.getMinutes() / 60.0));
second.rotation.y = -((Math.PI * 2) * (now.getSeconds() / 60.0));
camera.rotation.z = second.rotation.y;

window.addEventListener("resize", function() {
    renderer.setSize(WIDTH, HEIGHT);
    camera.aspect = WIDTH / HEIGHT;
    camera.updateProjectionMatrix();
});

//camera.position.set(0, 0, 0);
//camera.lookAt(scene.position);

// Testing TWEEN animation

var rotation_start = { angle: now.getSeconds() };
var rotation_end = { angle: rotation_start.angle + 1 };

var tween1 = new TWEEN.Tween(rotation_start).to(rotation_end, 1000)
    .easing(TWEEN.Easing.Elastic.InOut)
    .delay(0)
    .onUpdate(function() {
        second.rotation.y = -((Math.PI * 2) * (this.angle / 60.0));
    })
    .onComplete(function() {
        rotation_start.angle = new Date().getSeconds();
        rotation_end.angle = rotation_start.angle + 1;


    })
    .start();

tween1.chain(tween1);
//controls = new THREE.OrbitControls(camera, renderer.domElement);

var update = function () {
    minute.rotation.y -= 0.0018 / 60;
    hour.rotation.y -= 0.0018 / 60 / 12;
    camera.rotation.z -= 0.0018;
    TWEEN.update();
    //controls.update();
};

// Browser Animation Loop
var animate = function () {
    update();

    requestAnimationFrame(animate);
    renderer.render(scene, camera);
};
animate();