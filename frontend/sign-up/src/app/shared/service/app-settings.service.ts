import { IAppSettings } from '../model/app-settings.model';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { LoggerService } from './logger.service';
import { LogHelper } from '../helper/log.helper';

@Injectable()
export class AppSettingsService {
	private readonly _settings: IAppSettings = {} as IAppSettings;

	public constructor(private _logger: LoggerService) {
		this._settings = environment.settings;
		_logger?.info(LogHelper.pretty(this._settings));
	}

	public get settings(): IAppSettings {
		return this._settings;
	}
}
