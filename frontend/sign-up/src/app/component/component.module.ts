import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupStepFirstComponent } from './signup-step-first/signup-step-first.component';
import { SignupStepSecondComponent } from './signup-step-second/signup-step-second.component';
import { SignupResultComponent } from './signup-result/signup-result.component';

@NgModule({
	declarations: [SignupStepFirstComponent, SignupStepSecondComponent, SignupResultComponent],
	imports: [CommonModule],
})
export class ComponentModule {}
