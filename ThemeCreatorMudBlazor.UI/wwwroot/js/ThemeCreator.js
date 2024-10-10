window.getComputedStyleProperty = function (propertyName) {
    const style = getComputedStyle(document.documentElement);
    return style.getPropertyValue(propertyName);
};

window.mudpopoverHelper.placePopover = function (popoverNode, classSelector) {

    if (popoverNode && popoverNode.parentNode) {
        const id = popoverNode.id.substr(8);
        const popoverContentNode = document.getElementById('popovercontent-' + id);

        if (!popoverContentNode) {
            return;
        }

        if (popoverContentNode.classList.contains('mud-popover-open') == false) {
            return;
        }

        if (classSelector) {
            if (popoverContentNode.classList.contains(classSelector) == false) {
                return;
            }
        }
        const boundingRect = popoverNode.parentNode.getBoundingClientRect();

        if (popoverContentNode.classList.contains('mud-popover-relative-width')) {
            popoverContentNode.style['max-width'] = (boundingRect.width) + 'px';
        }

        const selfRect = popoverContentNode.getBoundingClientRect();
        const classList = popoverContentNode.classList;
        const classListArray = Array.from(popoverContentNode.classList);

        const postion = window.mudpopoverHelper.calculatePopoverPosition(classListArray, boundingRect, selfRect);
        let left = postion.left;
        let top = postion.top;
        let offsetX = postion.offsetX;
        let offsetY = postion.offsetY;

        if (classList.contains('mud-popover-overflow-flip-onopen') || classList.contains('mud-popover-overflow-flip-always')) {

            const appBarElements = document.getElementsByClassName("mud-appbar mud-appbar-fixed-top");
            let appBarOffset = 0;
            if (appBarElements.length > 0) {
                appBarOffset = appBarElements[0].getBoundingClientRect().height;
            }

            const graceMargin = window.mudpopoverHelper.flipMargin;
            const deltaToLeft = left + offsetX;
            const deltaToRight = window.innerWidth - left - selfRect.width;
            const deltaTop = top - selfRect.height - appBarOffset;
            const spaceToTop = top - appBarOffset;
            const deltaBottom = window.innerHeight - top - selfRect.height;
            //console.log('self-width: ' + selfRect.width + ' | self-height: ' + selfRect.height);
            //console.log('left: ' + deltaToLeft + ' | rigth:' + deltaToRight + ' | top: ' + deltaTop + ' | bottom: ' + deltaBottom + ' | spaceToTop: ' + spaceToTop);

            let selector = popoverContentNode.mudPopoverFliped;

            if (!selector) {
                if (classList.contains('mud-popover-top-left')) {
                    if (deltaBottom < graceMargin && deltaToRight < graceMargin && spaceToTop >= selfRect.height && deltaToLeft >= selfRect.width) {
                        selector = 'top-and-left';
                    } else if (deltaBottom < graceMargin && spaceToTop >= selfRect.height) {
                        selector = 'top';
                    } else if (deltaToRight < graceMargin && deltaToLeft >= selfRect.width) {
                        selector = 'left';
                    }
                } else if (classList.contains('mud-popover-top-center')) {
                    if (deltaBottom < graceMargin && spaceToTop >= selfRect.height) {
                        selector = 'top';
                    }
                } else if (classList.contains('mud-popover-top-right')) {
                    if (deltaBottom < graceMargin && deltaToLeft < graceMargin && spaceToTop >= selfRect.height && deltaToRight >= selfRect.width) {
                        selector = 'top-and-right';
                    } else if (deltaBottom < graceMargin && spaceToTop >= selfRect.height) {
                        selector = 'top';
                    } else if (deltaToLeft < graceMargin && deltaToRight >= selfRect.width) {
                        selector = 'right';
                    }
                }

                else if (classList.contains('mud-popover-center-left')) {
                    if (deltaToRight < graceMargin && deltaToLeft >= selfRect.width) {
                        selector = 'left';
                    }
                }
                else if (classList.contains('mud-popover-center-right')) {
                    if (deltaToLeft < graceMargin && deltaToRight >= selfRect.width) {
                        selector = 'right';
                    }
                }
                else if (classList.contains('mud-popover-bottom-left')) {
                    if (deltaTop < graceMargin && deltaToRight < graceMargin && deltaBottom >= 0 && deltaToLeft >= selfRect.width) {
                        selector = 'bottom-and-left';
                    } else if (deltaTop < graceMargin && deltaBottom >= 0) {
                        selector = 'bottom';
                    } else if (deltaToRight < graceMargin && deltaToLeft >= selfRect.width) {
                        selector = 'left';
                    }
                } else if (classList.contains('mud-popover-bottom-center')) {
                    if (deltaTop < graceMargin && deltaBottom >= 0) {
                        selector = 'bottom';
                    }
                } else if (classList.contains('mud-popover-bottom-right')) {
                    if (deltaTop < graceMargin && deltaToLeft < graceMargin && deltaBottom >= 0 && deltaToRight >= selfRect.width) {
                        selector = 'bottom-and-right';
                    } else if (deltaTop < graceMargin && deltaBottom >= 0) {
                        selector = 'bottom';
                    } else if (deltaToLeft < graceMargin && deltaToRight >= selfRect.width) {
                        selector = 'right';
                    }
                }
            }
            
            if (selector && selector != 'none') {
                const newPosition = window.mudpopoverHelper.getPositionForFlippedPopver(classListArray, selector, boundingRect, selfRect);
                left = newPosition.left;
                top = newPosition.top;
                offsetX = newPosition.offsetX;
                offsetY = newPosition.offsetY;
                popoverContentNode.setAttribute('data-mudpopover-flip', 'flipped');
            }
            else {
                // did not flip, ensure the left and top are inside bounds
                if (left + offsetX < 0) {
                    left = Math.max(0, left + offsetX);
                    // set offsetX to 0 to avoid double offset
                    offsetX = 0;
                }
                if (top + offsetY < appBarOffset ) {
                    top = Math.max(appBarOffset, top + offsetY);
                    // set offsetY to 0 to avoid double offset
                    offsetY = 0;
                }
                popoverContentNode.removeAttribute('data-mudpopover-flip');
            }

            if (classList.contains('mud-popover-overflow-flip-onopen')) {
                if (!popoverContentNode.mudPopoverFliped) {
                    popoverContentNode.mudPopoverFliped = selector || 'none';
                }
            }
        }

        if (popoverContentNode.classList.contains('mud-popover-fixed')) {
        }
        else if (window.getComputedStyle(popoverNode).position == 'fixed') {
            popoverContentNode.style['position'] = 'fixed';
        }
        else {
            offsetX += window.scrollX;
            offsetY += window.scrollY
        }

        popoverContentNode.style['left'] = (left + offsetX) + 'px';
        popoverContentNode.style['top'] = (top + offsetY) + 'px';

        if (window.getComputedStyle(popoverNode).getPropertyValue('z-index') != 'auto') {
            popoverContentNode.style['z-index'] = window.getComputedStyle(popoverNode).getPropertyValue('z-index');
            popoverContentNode.skipZIndex = true;
        }
    }
}