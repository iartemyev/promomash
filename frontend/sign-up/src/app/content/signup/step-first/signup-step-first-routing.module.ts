import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { SignupStepFirstComponent } from './signup-step-first.component';

const routes: Routes = [
	{
		path: '',
		component: SignupStepFirstComponent,
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class SignupStepFirstRoutingModule {}
