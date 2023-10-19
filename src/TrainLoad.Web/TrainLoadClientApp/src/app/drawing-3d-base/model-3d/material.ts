import * as THREE from 'three';

export const colorName = 0x3276B1;
export const supportColorName = 0x726d6d;
export const color = new THREE.Color(colorName);

export const material = new THREE.MeshBasicMaterial({
    vertexColors: true,
    side: THREE.DoubleSide,
    color: colorName,
});

export const materialLoad = new THREE.MeshBasicMaterial({
    color: colorName,
});

export const materialSupport = new THREE.MeshBasicMaterial({
    color: supportColorName,
    transparent: true,
    opacity: 0.3,
});
