import { Component, OnInit } from '@angular/core';
import { LoggerService } from '../../shared/service/logger.service';

@Component({
	selector: 'app-signup',
	template: ` <router-outlet></router-outlet>`,
})
export class SignupComponent implements OnInit {
	public constructor(private _logger: LoggerService) {}

	public ngOnInit(): void {
		this._logger.info('SignupComponent ngOnInit');
	}
}
