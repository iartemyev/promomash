import { RouterModule, Routes } from '@angular/router';
import { SignupStepSecondComponent } from './signup-step-second.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
	{
		path: '',
		component: SignupStepSecondComponent,
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class SignupStepSecondRoutingModule {}
