window.getComputedStyleProperty = function (propertyName) {
    const style = getComputedStyle(document.documentElement);
    return style.getPropertyValue(propertyName);
};

window.attachMouseUp = (dotNetHelper) => {
    const onMouseUp = () => {
        dotNetHelper.invokeMethodAsync("OnMouseUp");
        window.removeEventListener("mouseup", onMouseUp);
    };
    window.addEventListener("mouseup", onMouseUp);
};

window.getEditableContent = (element) => {
    return element.innerText || '';
};
