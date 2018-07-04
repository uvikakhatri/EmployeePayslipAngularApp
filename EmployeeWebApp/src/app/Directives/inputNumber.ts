import {Directive, HostListener, Input} from '@angular/core';

@Directive({
    selector: '[inputNumber]'
})
export class InputNumberDirective {

    @Input() min: number = 0; // will be input
    @Input() max: number; // will be input
    @Input() isDecimal: boolean;

    @HostListener('keypress', ['$event']) sanitizeValue(event: KeyboardEvent): boolean {

     
      if (this.isDecimal == undefined) this.isDecimal = true;
        const targetVal: number = Number((<HTMLInputElement>event.target).value);

        const charCode = (event.which) ? event.which : 0;
       
        if (charCode == 0 || ([8].indexOf(charCode) !== -1)) return true;

        if (charCode == 46 && (<HTMLInputElement>event.target).value.indexOf(".") != -1) return false;

        if ((charCode >= 48 && charCode < 58) || (charCode == 46 && this.isDecimal)) {
            if (this.min !== null && targetVal < this.min) {
                return false;
            }
            if (this.max !== null && targetVal > this.max) {
                return false;
            }
            return true;
        }
        return false;
    }
}
