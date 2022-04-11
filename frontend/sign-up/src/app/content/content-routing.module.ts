import { RouterModule, Routes } from '@angular/router';
import { ContentComponent } from './content.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
	{
		path: '',
		pathMatch: 'full',
		redirectTo: '/signup',
	},
	{
		path: '',
		component: ContentComponent,
		children: [
			{
				path: 'signup',
				loadChildren: () => import('./signup/signup.module').then((m) => m.SignupModule),
			},
		],
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class ContentRoutingModule {}
